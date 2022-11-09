import { Component, OnInit, Input, EventEmitter, Output,OnChanges,DoCheck } from '@angular/core';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {

  constructor() { }

  @Input('img') postImg ='';
  @Output() imgSelected = new EventEmitter<string>();

  ngOnInit(): void {
  }

}
