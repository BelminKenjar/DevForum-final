import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-topic-form',
  templateUrl: './topic-form.component.html',
  styleUrls: ['./topic-form.component.css']
})
export class TopicFormComponent implements OnInit {

  @Input() public formGroup: any;
  @Input() public f: any;
  @Output() submit = new EventEmitter();
  @Output() byteFile = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  FileInputChange = async (e: Event) => {
    const file = e.target['files'][0]
    const byteFile = await this.getAsByteArray(file);
    let bytes = Array.from(byteFile);
    this.byteFile.emit(bytes);
  }

  async getAsByteArray(file) {
    return new Uint8Array(await this.readFile(file))
  }

  readFile(file): Promise<any> {
    return new Promise((resolve, reject) => {
      // Create file reader
      let reader = new FileReader()

      // Register event listeners
      reader.addEventListener("loadend", e => resolve(reader.result))
      reader.addEventListener("error", reject)

      // Read file
      reader.readAsArrayBuffer(file)
    })
  }
}
