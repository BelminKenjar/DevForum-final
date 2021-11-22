import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubtopicItemComponent } from './subtopic-item.component';

describe('SubtopicItemComponent', () => {
  let component: SubtopicItemComponent;
  let fixture: ComponentFixture<SubtopicItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubtopicItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubtopicItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
