import { Component } from '@angular/core';
import { MarketService } from './shared/market.service';
import { Deck } from './shared/deck.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-market',
  templateUrl: './market.component.html',
  providers: [DatePipe]
})
export class MarketComponent {
  deck: Deck;
  constructor(private marketService: MarketService, private datepipe: DatePipe) { }

  ngOnInit() {
    this.loadTable();
  }

  loadTable() {
    this.marketService.getDecks().then(res => {
     
      res.postDate = this.datepipe.transform(res.postDate, 'MM/dd/yyyy');
      this.deck = res;
    })
  }
}
