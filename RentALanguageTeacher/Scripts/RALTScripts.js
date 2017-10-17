
//Testimonal Rotator
$(document).ready(function () {
    if ($('#testimonials').length > 0) {
        var items = (Math.floor(Math.random() * ($('#testimonials li').length)));
        $('#testimonials li').hide().eq(items).show();

        function next() {
            $('#testimonials li:visible').delay(5000).fadeOut('slow', function () {
                $(this).appendTo('#testimonials ul');
                $('#testimonials li:first').fadeIn('slow', next);
            });
        }
        next();
    }
});



//Coin Slider
$(document).ready(function () {

    $('#coin-slider').coinslider({ width: 800, height: 400, delay: 4000, links: false, hoverPause: false, navigation: true });

});



//function checkCookie() {
//    var user = getCookie("username");
//    if (user != "") {
//        alert("Welcome again " + user);
//    }
//    else {
//        user = prompt("Please enter your name:", "");
//        if (user != "" && user != null) {
//            setCookie("username", user, 365);
//        }
//    }
//}


//$(function () {
//    $(document).tooltip();
//    $("#tabs").tabs();
//});



$(document).ready(function () {
    if ($('#list').length > 0) {
        var i = 0,
        delay = 2000,
        animate = 400;
        function animateList() {
            var imax = $("ul#list li").length - 1;
            $("ul#list li:eq(" + i + ")")
                    .animate({ "fontSize": "20px" }, animate)
                    .animate({ "fontSize": "20px" }, delay)
                    .animate({ "fontSize": "16px" }, animate, function () {

                        (i == imax) ? i = 0 : i++;
                        animateList();
                    });

        };

        animateList();
    }
});
