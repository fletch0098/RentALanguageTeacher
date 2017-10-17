//Javascript for The Rent Page
$(document).ready(function () {
    $("#50Hours").hover(

        function () {
            $("#50Hours").css({ "text-align": "center", "background-color": "rgb(237, 172, 28)", "border":"1px solid #000000" });
            
        }, function () {

            $("#50Hours").css({ "text-align": "center", "background-color": "rgb(102, 255, 51)", "border":"1px solid #ffffff" });
        }
       );
}); 

$(document).ready(function () {
    $("#25Hours").hover(


        function () {
            $("#25Hours").css({ "text-align": "center", "background-color": "rgb(237, 172, 28)", "border":"1px solid #000000" });
            
        }, function () {

            $("#25Hours").css({ "text-align": "center", "background-color": "rgb(255, 255, 51)", "border":"1px solid #ffffff" });
        }
       );
}); 

$(document).ready(function () {
    $("#10Hours").hover(


        function () {
            $("#10Hours").css({ "text-align": "center", "background-color": "rgb(237, 172, 28)", "border":"1px solid #000000" });
            
        }, function () {

            $("#10Hours").css({ "text-align": "center", "background-color": "rgb(102, 204, 255)", "border":"1px solid #ffffff"  });
        }
       );
}); 

$( "#10Hours" ).click(function() {
  SelectPackage(this);
});

$( "#50Hours" ).click(function() {
  SelectPackage(this);
});

$( "#25Hours" ).click(function() {
  SelectPackage(this);
});

function SelectPackage(package){

var PackageName= $(package).attr('id');
var PackagePrice= $(package).attr('price');

    //Call WebMethod
    $.ajax({
        type: "POST",
        url: "/Default.aspx/SelectPackage",
        data: "{'ItemName': '" + PackageName + "', 'ItemPrice': '" + PackagePrice + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //Success Function
        success: function (ReturnValue) {

			if (ReturnValue.d == "NoUser") {
                
                var n = noty({ text: "Please log in to continue", type: 'alert' });
				OpenSlider('LogIn');

            }
            else if (ReturnValue.d != "false") {
                
               // window.location.href = '/checkout' + ReturnValue.d;
			   window.location.href = 'https://www.rentalanguageteacher.com/checkout' + ReturnValue.d;

            }
            else {
                var n = noty({ text: "There was an error, Please Try again", type: 'error' });
            }
        },
        //Error
        error: function (request, status, error) {
            var n = noty({ text: "There was an error, Please Try again", type: 'error' });
        },
    });


};
