import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewDocumentPopupComponent } from './new-document-popup.component';

describe('NewDocumentPopupComponent', () => {
  let component: NewDocumentPopupComponent;
  let fixture: ComponentFixture<NewDocumentPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NewDocumentPopupComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewDocumentPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
