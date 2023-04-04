import { Component } from '@angular/core';
import { Article } from './model/article.model';
import { ArticleServiceService } from './service/article.service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  articles: Article[]= [];

  columns: any[]=[];

  constructor(private articleService: ArticleServiceService) {
    this.columns = [
      { dataField: 'id', allowEditing: false },
      { dataField: 'name' },
      { dataField: 'description' },
      { dataField: 'price' },
      { dataField: 'quantity' },
    ];
    this.articleService.getAllArticles().subscribe(data => {this.articles = data;});
    console.log("load data")
  }

  
  onRowUpdated(event: any) {
    console.log("test11")
    this.articleService.updateArticle( event.newData).subscribe(data => {
      // Mettre à jour la source de données
    });
  }
  
  onRowInserted(event: any) {
    console.log("test11")
    this.articleService.addArticle(event.data).subscribe(data => {
      // Mettre à jour la source de données
    });
  }
  onInitNewRow(event: any) {
    // Ne rien faire
  }
  onRowRemoved(event: any) {
    this.articleService.deleteArticle(event.data.id).subscribe(data => {
    });
  }
}