import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Article } from '../model/article.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArticleServiceService {
  private apiUrl = 'https://localhost:7143/Article';

  constructor(private http: HttpClient) { }

  getAllArticles(): Observable<Article[]> {
    return this.http.get<Article[]>("https://localhost:7143/Article");
  }

  getArticleById(id: number): Observable<Article> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Article>(url);
  }

  addArticle(article: Article): Observable<Article> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Article>(this.apiUrl, article, { headers: headers });
  }

  updateArticle(article: Article): Observable<Article> {
    const url = `${this.apiUrl}/${article.id}`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<Article>(url, article, { headers: headers });
  }

  deleteArticle(id: number): Observable<Article> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<Article>(url);
  }
}
