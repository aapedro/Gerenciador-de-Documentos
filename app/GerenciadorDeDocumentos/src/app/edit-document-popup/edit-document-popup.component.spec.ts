import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDocumentPopupComponent } from './edit-document-popup.component';

describe('EditDocumentPopupComponent', () => {
  let component: EditDocumentPopupComponent;
  let fixture: ComponentFixture<EditDocumentPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditDocumentPopupComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditDocumentPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
