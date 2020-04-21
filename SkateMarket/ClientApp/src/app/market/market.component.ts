import { Component } from '@angular/core';
import { Deck } from './shared/deck.model';
import { DatePipe } from '@angular/common';
import { DeckService } from './shared/deck.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-market',
  templateUrl: './market.component.html',
  providers: [DatePipe]
})
export class MarketComponent {
  deck: Deck; 
  form: FormGroup;
  showview: boolean = false;
  deckitem: any=[];
  constructor(private deckService: DeckService, private datepipe: DatePipe) { }

  ngOnInit() {
    this.loadTable();

    this.form = new FormGroup({
      Brand: new FormControl(''),
      PostDate: new FormControl(''),
      Size: new FormControl(''),
      Price: new FormControl(''),
    });

  }
  onSubmit(data) {
    this.deckService.addDecks(data).subscribe(res => {
      this.loadTable();
    })
  }
  loadTable() {
    this.deckService.getDecks().then(res => {
      res.postDate = this.datepipe.transform(res.postDate, 'MM/dd/yyyy');
      this.deck = res;
    })
  }
  delete(id) {
    this.deckService.deleteDecks(id).subscribe(res => {
      this.loadTable();
    })
  }

  view(item) {
    this.showview = true;
    this.deckitem = item;
  }
  
}
