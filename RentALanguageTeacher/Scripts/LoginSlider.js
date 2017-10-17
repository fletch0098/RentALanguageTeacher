$(document).ready(function() {
    $("div.panel_button").click(function () {
        var result = $("div#panel").height();

        if (result == 0) {

            $("div#panel").animate({
                height: "500px"
            })
            .animate({
                height: "410px"
            }, "fast");

            //$("IMG#PanelButton").rotate(-45);
            //$("IMG#PanelButton").delay(8000);
            //$("IMG#PanelButton").rotate(-45);


            $("IMG#PanelButton").attr('src', '/images/GetConnectedClose.png');
            //$("div.panel_button").toggleClass('panel_button_open');
        }
        else {
            $("div#panel").animate({
                height: "500px"
            })
            .animate({
                height: "410px"
            }, "fast");

            $("div#panel").animate({
                height: "0px"
            }, "fast");

            //$("IMG#PanelButton").rotate(45);
            //$("IMG#PanelButton").delay(8000);
            //$("IMG#PanelButton").rotate(45);

            $("IMG#PanelButton").attr('src', '/images/GetConnectedOpen.png');
           // $("div.panel_button").toggleClass('panel_button_open');
        }
	});	
		
});


$(document).ready(function () {
    $("div.panel_button").hover(


        function () {

            var image2 = $("IMG#PanelButton").attr('src');

            
            if (image2 == '/images/GetConnectedOpen.png') {

            

            $("IMG#PanelButton").attr('src', '/images/GetConnectedHover.png');
        }}, function () {

            var image = $("IMG#PanelButton").attr('src');

            if (image == '/images/GetConnectedHover.png') {

                $("IMG#PanelButton").attr('src', '/images/GetConnectedOpen.png');
            }
        }
       );
});

function OpenSlider(Tab) {

    $(document).ready(function () {

        $("div#panel").animate({
            height: "500px"
        })
                .animate({
                    height: "410px"
                }, "fast");

        //$("IMG#PanelButton").rotate(-45);
        //$("IMG#PanelButton").delay(8000);
        //$("IMG#PanelButton").rotate(-45);


        $("IMG#PanelButton").attr('src', '/images/GetConnectedClose.png');
        //$("div.panel_button").toggleClass('panel_button_open');

        if (Tab == 'LogIn') {
            $("#tabs").tabs("option", "active", 1);
        }
        else {
            $("#tabs").tabs("option", "active", 0);
        };
    });
   
}

function ChangeTabsLogIn() {

    $("#tabs").tabs("option", "active", 1);
}

function ChangeTabsSignUp() {

    $("#tabs").tabs("option", "active", 0);

}

function CloseSlider() {

    $("div#panel").animate({
        height: "500px"
    })
             .animate({
                 height: "410px"
             }, "fast");

    $("div#panel").animate({
        height: "0px"
    }, "fast");

    //$("IMG#PanelButton").rotate(45);
    //$("IMG#PanelButton").delay(8000);
    //$("IMG#PanelButton").rotate(45);

    $("IMG#PanelButton").attr('src', '/images/GetConnectedOpen.png');
    // $("div.panel_button").toggleClass('panel_button_open');
}