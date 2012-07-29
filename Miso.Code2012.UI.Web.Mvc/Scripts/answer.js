$(function () {

    var answerLoadUrl = "/api/answer";

    var data = [];
    var viewModel = {
        answers: ko.observableArray(data)
    };
    ko.applyBindings(viewModel);

    $.ajax({
        url: answerLoadUrl,
        success: function (answers) {                     
           viewModel.answers(answers);
        }
    });

});