import { Component, Output, EventEmitter } from '@angular/core';
import { NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-edit-document-popup',
  standalone: true,
  imports: [NgIf, FormsModule],
  templateUrl: './edit-document-popup.component.html',
  styleUrl: './edit-document-popup.component.css'
})
export class EditDocumentPopupComponent {
  @Output() closePopup = new EventEmitter();
  @Output() submitDocument = new EventEmitter();

  document = {
    name: '',
    description: '',
    status: 'pending',
    file: null
  };

  submitForm() {
    this.submitDocument.emit(this.document);
    this.closePopup.emit();
  }

  getStatusLabel(i: number): string {
    switch(i) {
      case 0: return "Pendente"
      case 1: return "Aprovado"
      case 2: return "Negado"
      default: return "Pendente"
    }
  }
}
