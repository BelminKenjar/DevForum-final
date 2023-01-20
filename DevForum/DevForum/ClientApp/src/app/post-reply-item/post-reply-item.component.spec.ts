import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostReplyItemComponent } from './post-reply-item.component';

describe('PostReplyItemComponent', () => {
  let component: PostReplyItemComponent;
  let fixture: ComponentFixture<PostReplyItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostReplyItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostReplyItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
