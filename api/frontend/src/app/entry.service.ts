import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Entries} from "./entry.model";
import {firstValueFrom, Observable} from "rxjs";

@Injectable({
providedIn: "root",
})
export class EntryService {
  private apiUrl = 'http://localhost:5287/api/';
  entries: Entries[] = [];
  latestEntry: Entries | null = null;

  constructor(private http: HttpClient) {
  }

  async fetchEntries(userId: number){
    const call = this.http.get<Entries[]>(`${this.apiUrl}usersentries?userId=${userId}`);
    this.entries = await firstValueFrom(call);
    this.latestEntry = this.entries[this.entries.length - 1];
  }

  async addEntry(entry: Entries){
    const call = this.http.post<boolean>(`${this.apiUrl}addentry`, entry);
    const result = await firstValueFrom(call);
    if(result){
      await this.fetchEntries(1)
    }
  }

  async removeEntry(entryId: number) {
    const call = this.http.delete<boolean>(`${this.apiUrl}deleteentry?entryId=${entryId}`);
    const result = await firstValueFrom(call);
    if(result){
      await this.fetchEntries(1)
    }
  }
}
