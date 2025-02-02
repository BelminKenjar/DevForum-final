import { Component, NgZone } from '@angular/core';
import {Message, Profile} from '../../models/message';
import {ChatService} from '../../services/chat/chat.service';
import {ProfileService} from '../../services/profile/profile.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent {
  title = 'ChatApp';
  txtMessage  = 'Type a message';
  uniqueID: string = new Date().getTime().toString();

  guestName = '';
  messages = new Array<Message>();
  message = new Message();
  profile: Profile;

  constructor(
    private chatService: ChatService,
    private _ngZone: NgZone,
    private profileService: ProfileService
  ) {
    this.uniqueID = new Date().getTime().toString();
    this.subscribeToEvents();
    this.getUsername();
  }
  sendMessage(): void {
    if (this.txtMessage) {
      this.getUsername();
      this.message = new Message();
      this.message.clientUniqueId = this.uniqueID;
      this.message.guestName = this.guestName;
      this.message.type = 'sent';
      this.message.content = this.txtMessage;
      this.message.date = new Date();
      this.messages.push(this.message);
      this.chatService.sendMessage(this.message);
      this.txtMessage = '';
    }
  }
  private subscribeToEvents(): void {
    this.chatService.messageReceived.subscribe((message: Message) => {
      this._ngZone.run(() => {
        if (message.clientUniqueId !== this.uniqueID) {
          message.type = 'received';
          this.messages.push(message);
        }
      });
    });
  }
  private getUsername(): any {
    this.profileService.GetUserProfile().subscribe((x: any) => { this.profile = x; });
    if (this.profile) {
      this.guestName = this.profile.firstName + ' ' + this.profile.lastName;
    } else {
      this.guestName = 'Guest' + new Date().getTime().toString();
    }
  }
}
