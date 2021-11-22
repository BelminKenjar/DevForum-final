import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubtopicFormComponent } from './subtopic-form.component';

describe('SubtopicFormComponent', () => {
  let component: SubtopicFormComponent;
  let fixture: ComponentFixture<SubtopicFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubtopicFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubtopicFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
