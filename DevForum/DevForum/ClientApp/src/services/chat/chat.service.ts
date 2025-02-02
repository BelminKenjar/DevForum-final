import { EventEmitter, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Message } from '../../models/message';
import * as signalR from '@microsoft/signalr';
@Injectable({
  providedIn: 'root'
})
export class ChatService {
  messageReceived = new EventEmitter<Message>();
  connectionEstablished = new EventEmitter<Boolean>();
  private connectionIsEstablished = false;
  private _hubConnection: HubConnection;
  constructor() {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }
  sendMessage(message: Message) {
    this._hubConnection.invoke('NewMessage', message).catch(err => console.error(err));
  }
  private createConnection() {
    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(window.location.href + 'MessageHub', {skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets})
      .build();
  }
  private startConnection(): void {
    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
        this.connectionEstablished.emit(true);
      })
      .catch(err => {
        console.log('Error while establishing connection, retrying...');
        setTimeout(() => { this.startConnection(); }, 5000);
      });
  }
  private registerOnServerEvents(): void {
    this._hubConnection.on('MessageReceived', (data: any) => {
      this.messageReceived.emit(data);
    });
  }
}
