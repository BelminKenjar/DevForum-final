import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubtopicDetailsComponent } from './subtopic-details.component';

describe('SubtopicDetailsComponent', () => {
  let component: SubtopicDetailsComponent;
  let fixture: ComponentFixture<SubtopicDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubtopicDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubtopicDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
