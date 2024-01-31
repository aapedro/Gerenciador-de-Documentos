import { Component, Output, EventEmitter} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgIf } from '@angular/common';
import { NewDocumentPopupComponent } from '../new-document-popup/new-document-popup.component';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [NewDocumentPopupComponent, NgIf],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  @Output() documentAdded = new EventEmitter();

  constructor(private http: HttpClient) { }
  
  isDocumentPopupOpen = false;

  toggleDocumentPopup() {
    this.isDocumentPopupOpen = this.isDocumentPopupOpen ? false : true;
  }

  closeDocumentPopup() {
    this.isDocumentPopupOpen = false;
  }

  handleDocumentSubmission(documentData: any) {
    const formData = new FormData();

    formData.append('name', documentData.name);
    formData.append('description', documentData.description);
    formData.append('status', documentData.status.toUpperCase());
    formData.append('file', documentData.file);

    console.log(documentData)
    this.http.post<Document>(`http://localhost:5000/api/documents`, formData).subscribe(() => {})
    this.documentAdded.emit()
  }

  getStatusLabel(i: string): number {
    switch(i) {
      case "pending": return 0
      case "approved": return 1
      case "denied": return 2
      default: return 0
    }
  }
}
