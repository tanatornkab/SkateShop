import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment.prod';
@Injectable({
  providedIn: 'root',
})
export class DeckService {
  private configUrl = environment.apiBaseUrl;
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  } 
  getDecks() {
    return this.http.get<any>(this.configUrl + 'Decks/GetDecks').toPromise();
  }
  getDeck(id) {
    return this.http.get<any>(this.configUrl + 'Decks/GetDeck'+id).toPromise();
  }
  addDecks(deck) {
    var data = JSON.stringify(deck);
    return this.http.post(this.configUrl + 'Decks/AddDeck', data, this.httpOptions)
      .pipe(
        retry(1)
      )
  }
  editDecks(deck) {
    var data = JSON.stringify(deck);
    return this.http.put(this.configUrl + 'Decks/PutDeck', data, this.httpOptions).toPromise();
  }
  deleteDecks(id) {
    return this.http.delete(this.configUrl + 'Decks/DeleteDeck/'+id);
  }
}
