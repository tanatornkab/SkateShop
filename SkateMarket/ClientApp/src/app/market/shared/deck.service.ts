import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class DeckService {
  private configUrl = 'http://localhost:4000/api/';
  constructor(private http: HttpClient) { }

  getDecks() {
    return this.http.get<any>(this.configUrl + 'Decks').toPromise();
  }
}
