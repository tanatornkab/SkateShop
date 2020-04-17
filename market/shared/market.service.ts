import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Deck } from './deck.model';
import { Observable, of } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class MarketService {
  private configUrl = 'http://localhost:4000/api/Decks';
  constructor(private http: HttpClient) { }

  getDecks(): Observable<Deck[]> {
    return this.http.get<Deck[]>('http://localhost:4000/api/Decks');
  }
}
