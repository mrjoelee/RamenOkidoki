function CRateClick(rating) {
    $("#lblRating").val(rating);
    for (var i = 1; i <= rating; i++) {
        $("#span" + i).attr('class', 'fas fa-star');
    }

    for (var i = rating + 1; i <= 5; i++) {
        $("#span" + i).attr('class', 'far fa-star');
    }

}


//function CRateOut(rating) {
//    for (var i = 1; i <= rating; i++) {
//        $("#span" + i).attr('class', 'far fa-star');
//    }
//}


//function CRateOver(rating) {
//    for (var i = 1; i <= rating; i++) {
//        $("#span" + i).attr('class', 'fas fa-star');
//    }
//}


//function CRateSelected() {
//    var rating = $("#lblRating").val();
//    for (var i = 1; i <= rating; i++) {
//        $("#span" + i).attr('class', 'far fa-star');
//    }
// }
