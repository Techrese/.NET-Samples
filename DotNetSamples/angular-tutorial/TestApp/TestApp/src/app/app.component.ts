import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'TestApp';
  
  images = ['https://picsum.photos/id/237/500/50','https://picsum.photos/id/237/500/50','https://picsum.photos/id/237/500/50','https://picsum.photos/id/237/500/50'];

  imgUrl = 'https://picsum.photos/id/237/500/50';

  changeImage(e: KeyboardEvent) {
      this.imgUrl = (e.target as HTMLInputElement).value;
  }

  logImg(event: string) {
    console.log(event);
  }
}
