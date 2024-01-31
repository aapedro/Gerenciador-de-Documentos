import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Document } from '../../models/document.model';
import { NgFor } from '@angular/common';
import { CommonModule, Location } from '@angular/common';
import { HttpHeaders } from '@angular/common/http';
import { saveAs } from 'file-saver';
import { EditDocumentPopupComponent } from '../edit-document-popup/edit-document-popup.component';

@Component({
  selector: 'app-document-table',
  templateUrl: './document-table.component.html',
  standalone: true,
  imports: [NgFor, CommonModule, EditDocumentPopupComponent],
  styleUrls: ['./document-table.component.css']
})
export class DocumentTableComponent implements OnInit {

  documents: Document[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<any[]>(`http://localhost:5000/api/documents`).subscribe(data => {
      this.documents = data;
    });
  }

  downloadDocument(id: number, fileName: string): void {
    const headers = new HttpHeaders({
      'Content-Type': 'application/octet-stream',
      'responseType': 'blob'
    });
    this.http.get(`http://localhost:5000/api/documents/${id}/download`, {responseType: 'blob'}).subscribe(data => {
      const cleanFileName = fileName.split("_").slice(1).join("_")
      saveAs(data, cleanFileName)
    })

  }

  refreshTable(): void {
    this.http.get<any[]>(`http://localhost:5000/api/documents`).subscribe(data => {
      this.documents = data;
      location.reload();
    }); 
  }

  isDocumentPopupOpen = false;
  currentDocumentId = 0

  openEditDocumentPopup(id: number) {
    this.isDocumentPopupOpen = this.isDocumentPopupOpen ? false : true;
    this.currentDocumentId = id
  }

  closeDocumentPopup() {
    this.isDocumentPopupOpen = false;
  }

  editDocument(data: any): void {
    const body = {
      "Description": data.description,
      "Status": this.getStatusLabelReverse(data.status.toUpperCase())
    }
    this.http.patch(`http://localhost:5000/api/documents/${this.currentDocumentId}`, body).subscribe(() => {})
    this.closeDocumentPopup();
    this.refreshTable();
  }

  deleteDocument(id: number): void {
    this.http.delete(`http://localhost:5000/api/documents/${id}`).subscribe(() => {})
    this.refreshTable();
  }
  
  getStatusLabel(i: number): string {
    switch(i) {
      case 0: return "Pendente"
      case 1: return "Aprovado"
      case 2: return "Negado"
      default: return "Pendente"
    }
  }

  getStatusLabelReverse(i: string): number {
    switch(i) {
      case "PENDING": return 0
      case "APPROVED": return 1
      case "DENIED": return 2
      default: return 0
    }
  }
}
