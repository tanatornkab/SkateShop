import { Component } from '@angular/core';
import { MarketService } from './shared/market.service';
import { Deck } from './shared/deck.model';

@Component({
  selector: 'app-market',
  templateUrl: './market.component.html',
})
export class MarketComponent {
  deck: Deck;
  constructor(private marketService: MarketService) { }

  ngOnInit() {
    this.marketService.getDecks().subscribe(res => {
      console.log(res)
    })
  }
}
