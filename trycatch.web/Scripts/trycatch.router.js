$(function () {
	'use strict';

	if (window.app === undefined) {
		window.app = {};
	}

	app.ApplicationRouter = Backbone.Router.extend({
		routes: {
			'': 'articles',
			'article/:id': 'article',
			'*actions': 'articles'
		},
		articles: function () {
			var articles = new app.Articles(),
				articlesView = new app.ArticlesView({ model: articles });

			articles.load(function () {
				articlesView.render();
			});
		},
		article: function (id) {
			console.log(id);
			var article = new app.Article({ Id: id }),
				articleView = new app.ArticleView({ model: article });

			app.Params['$skip'] = 0;
			article.load(function () {
				articleView.render();
			});
		}
	});

	app.router = new app.ApplicationRouter();
	Backbone.history.start();
});