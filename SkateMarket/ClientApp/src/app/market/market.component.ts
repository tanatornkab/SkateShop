import { Component } from '@angular/core';
import { Deck } from './shared/deck.model';
import { DatePipe } from '@angular/common';
import { DeckService } from './shared/deck.service';

@Component({
  selector: 'app-market',
  templateUrl: './market.component.html',
  providers: [DatePipe]
})
export class MarketComponent {
  deck: Deck;
  constructor(private deckService: DeckService, private datepipe: DatePipe) { }

  ngOnInit() {
    this.loadTable();
  }

  loadTable() {
    this.deckService.getDecks().then(res => {
      res.postDate = this.datepipe.transform(res.postDate, 'MM/dd/yyyy');
      this.deck = res;
    })
  }
}
