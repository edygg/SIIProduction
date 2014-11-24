
$(function () {


    var viewModel = {
        query: ko.observable('')
    };
    viewModel.people = ko.observableArray(data);

    ko.applyBindings(viewModel);

    viewModel = {
        // …

        search: function (value) {
            // remove all the current beers, which removes them from the view
            viewModel.people.removeAll();

            for (var x in people) {
                if (people[x].name.toLowerCase().indexOf(value.toLowerCase()) >= 0) {
                    viewModel.people.push(people[x]);
                }
            }
        }
    };

    viewModel.query.subscribe(viewModel.search);
});