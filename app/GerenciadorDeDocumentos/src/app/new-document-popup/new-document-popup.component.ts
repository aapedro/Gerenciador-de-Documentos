import { Component, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-new-document-popup',
  standalone: true,
  imports: [NgIf, FormsModule],
  templateUrl: './new-document-popup.component.html',
  styleUrl: './new-document-popup.component.css'
})
export class NewDocumentPopupComponent {
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

  handleFileInput(event: any) {
    this.document.file = event.target.files[0];
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

