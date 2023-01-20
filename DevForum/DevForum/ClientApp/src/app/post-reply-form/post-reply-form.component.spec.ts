import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostReplyFormComponent } from './post-reply-form.component';

describe('PostReplyFormComponent', () => {
  let component: PostReplyFormComponent;
  let fixture: ComponentFixture<PostReplyFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostReplyFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostReplyFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
