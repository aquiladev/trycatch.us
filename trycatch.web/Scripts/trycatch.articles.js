$(function () {
	'use strict';

	if (window.app === undefined) {
		window.app = {};
	}

	app.Article = Backbone.Model.extend({
		url: function () {
			return "/api/articles?key=" + this.get('Id');
		},
		idAttribute: 'Id',
		defaults: {
			Id: ''
		},
		load: function (callback) {
			var data = {};
			this.fetch({
				data: data,
				success: callback
			});
		}
	});

	app.Articles = Backbone.Collection.extend({
		url: '/api/articles',
		model: app.Article,
		currentPage: 0,
		getCount: function () {
			var count = app.ViewBlock.data('metadata')['@odata.count'];
			return parseInt((count === undefined) ? 0 : count);
		},
		getPagesCount: function () {
			return Math.ceil(this.getCount() / app.PageSize);
		},
		getPages: function () {
			var pages = [];
			var ellipse = '...';
			var interval = this._getInterval();
			if (interval.start > 0) {
				pages.push({
					text: ellipse
				});
			}
			for (var i = interval.start; i < interval.end; i++) {
				pages.push({
					text: i + 1,
					value: i,
					current: i == this.currentPage
				});
			}
			if (interval.end < this.getPagesCount()) {
				pages.push({
					text: ellipse
				});
			}
			return pages;
		},
		_getInterval: function () {
			var halfDisplayed = app.DisplayedPages / 2;
			var pages = this.getPagesCount();
			var current = parseInt(this.currentPage);
			return {
				start: Math.ceil(current > halfDisplayed ? Math.max(Math.min(current - halfDisplayed, (pages - app.DisplayedPages)), 0) : 0),
				end: Math.ceil(current > halfDisplayed ? Math.min(current + halfDisplayed, pages) : Math.min(app.DisplayedPages, pages))
			};
		},
		load: function (callback) {
			var data = $.extend(data, app.Params);
			data['$top'] = app.PageSize;
			this.fetch({
				data: data,
				reset: true,
				success: callback
			});
			$('.links').hide();

			$('body').addClass('OverviewArticles')
					.removeClass('DetailsArticle');
		}
	});

	app.ArticleView = Backbone.View.extend({
		el: app.ViewEl,
		template: _.template($('#article-template').html()),
		render: function () {
			this.$el.html(this.template(this.model.toJSON()));
			return this;
		}
	});

	app.ArticlesView = Backbone.View.extend({
		el: app.ViewEl,
		template: _.template($('#articles-template').html()),
		render: function () {
			this.$el.html(this.template(this.model.toJSON()));
			return this;
		},
		events: {
			'click .add-to-cart-button': 'addToCart',
			'click .page': 'goToPage',
			'click .first-page': 'goToFirstPage',
			'click .last-page': 'goToLastPage',
			'click .prev-page': 'goToPrevPage',
			'click .next-page': 'goToNextPage'
		},
		addToCart: function (e) {
			e.preventDefault();
			var id = $(e.currentTarget).data("id");
			trycatchCart.addtocart('/ShoppingCart/AddToCart?articleId=' + id);
			return false;
		},
		goToPage: function (object) {
			var target = object.target;
			this.model.currentPage = $(target).find('input:hidden').val();
			app.Params['$skip'] = parseInt(this.model.currentPage) * app.PageSize;
			this.updatePage();
		},
		goToFirstPage: function () {
			this.model.currentPage = 0;
			app.Params['$skip'] = 0;
			this.updatePage();
		},
		goToLastPage: function () {
			this.model.currentPage = this.model.getPagesCount() - 1;
			app.Params['$skip'] = parseInt(this.model.currentPage) * app.PageSize;
			this.updatePage();
		},
		goToPrevPage: function () {
			this.model.currentPage = parseInt(this.model.currentPage) - 1;
			app.Params['$skip'] = parseInt(this.model.currentPage) * app.PageSize;
			this.updatePage();
		},
		goToNextPage: function () {
			this.model.currentPage = parseInt(this.model.currentPage) + 1;
			app.Params['$skip'] = parseInt(this.model.currentPage) * app.PageSize;
			this.updatePage();
		},
		updatePage: function () {
			var self = this;
			this.model.load(function () {
				self.render();
			});
		}
	});
})