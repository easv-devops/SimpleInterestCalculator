import {Component, OnInit} from '@angular/core';
import {RouterOutlet} from '@angular/router';
import {Entries} from "./entry.model";
import {EntryService} from "./entry.service";
import {FormsModule} from "@angular/forms";
import {NgForOf, NgIf} from "@angular/common";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, NgIf, NgForOf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  principal: number = 0;
  rate: number = 0;
  time: number = 0;
  entries: Entries[] = [];
  latestEntry: Entries = {
    entryId: this.entries.length + 1,
    userId: 1, // You can set the user ID as needed
    principal: this.principal,
    rate: this.rate,
    time: this.time,
    totalInterest: 0
  };

  constructor(private service: EntryService) {
  }

  async ngOnInit() {
    await this.updateEntriesList();
  }

  calculateInterest(): void {
    // Calculate total interest based on the provided inputs
    const interest = (this.principal * this.rate * this.time) / 100;
    const totalInterest = this.principal! + interest;

    // Create a new entry
    this.latestEntry = {
      entryId: 0,
      userId: 1, // You can set the user ID as needed
      principal: this.principal,
      rate: this.rate,
      time: this.time,
      totalInterest: totalInterest
    };
  }

  async saveEntry() {
    await this.service.addEntry(this.latestEntry)
    await this.updateEntriesList();
  }

  async deleteEntry(id: number){
    await this.service.removeEntry(id);
    await this.updateEntriesList();
  }

  async updateEntriesList(){
    await this.service.fetchEntries(1);
    this.entries = this.service.entries
    this.latestEntry = this.entries[this.entries.length - 1];
  }

}
