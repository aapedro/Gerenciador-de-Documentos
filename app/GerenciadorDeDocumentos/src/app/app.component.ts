import { Component, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { DocumentTableComponent } from './document-table/document-table.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: true,
  styleUrl: './app.component.css',
  imports: [ReactiveFormsModule, HttpClientModule, RouterOutlet, NavbarComponent, DocumentTableComponent]
})
export class AppComponent {
  title = 'GerenciadorDeDocumentos';
  @ViewChild(DocumentTableComponent) documentTable!: DocumentTableComponent;

  refreshTable() {
    this.documentTable.refreshTable()
  }
}
