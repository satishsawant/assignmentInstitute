$(document).ready(function () {
    GetAllEnquiry();
    //GetCourseType();
 
});
var BaseURL = "http://45.35.4.250/institutemgmt/api/";

//Get All Enquiry
function GetAllEnquiry() {
    debugger;
    $.ajax({
        type: "GET",
        url: BaseURL + "Enquiry/GetAll",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            //var course = data.success;
            var arr = [];
            arr = data;
            $.each(arr, function (i, item) {
                var options = "<tr><td>" + item.ID + "</td><td>" + item.EnquiryName + "</td><td>" + item.Course + "</td> <td>" + item.Other + "</td> <td>" + item.DateOfEnq + "</td><td>" + item.FollowupDate + "</td><td>" + item.Remark + "</td></td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs'data-title='Edit' data-toggle='modal' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>";
                $('#enquirybody').append(options);
            }); //End of foreach Loop 
        },
        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}

//Create Enquiry
function CreateEnquiry() {
    debugger;
    var enquiry = {
  
        "EnquiryName": $("#enquiry").val(),
        "Course": $("#equcoursename").val(),
        "Other": $("#other").val(),
        "DateOfEnq": $("#enqdate").val(),
        "FollowupDate": $("#followdate").val(),
        "Remark": $("#remark").val()
    };
    $.ajax({
        type: "POST",
        url: BaseURL + "Enquiry/CreateEnquiry",
        data: JSON.stringify(enquiry),
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            alert("Create Succesfully");
        },
        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    })
}