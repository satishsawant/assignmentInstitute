<<<<<<< HEAD
﻿$(document).ready(function){
    GetAllLeave();
    GetAllLeaveType();
}
var BaseURL = "http://45.35.4.250/institutemgmt/api/";

//GET Leave By Id
=======
﻿//GET Leave By Id
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
function GetLeaveById() {
    $.ajax({
        type: "GET",
        url: "/api/Leave/Get",
        contentType: "json",
        dataType: "json",
        success: function (data) {
            //stringify
            var jsonData = JSON.stringify(data);
            //Parse JSON
            var objData = $.parseJSON(jsonData);
            var objData = $.parseJSON(jsonData);
            var id = objData.LeaveTypeID;
            var fromdate = objData.DateFrom;
            var todate = objData.DateTo;
            var reason = objData.Reason;
            var approve = objData.IsApproved;

            AppendTo('#leavetable');
        },
        error: function () {
            alert("Error");
        }
    });
}
<<<<<<< HEAD

=======
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
//GetAll Leave
function GetAllLeave() {
    $.ajax({
        type: "GET",
<<<<<<< HEAD
        url: BaseURL+"Leave/GetAll",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            //var course = data.success;
            var arr = [];
            arr = data;
            $.each(arr, function (i, item) {
                var options = "<tr><td>" + item.LeavesID +"<tr><td>" + item.LoginID + "</td><td>" + item.LeaveTypeID + "</td><td>" + item.DateFrom + "</td> <td>" + item.DateTo + "</td> <td>" + item.Reason + "</td><td>" + item.IsApproved+"<td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit' data-toggle='modal' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>";
                $('#leavebody').append(options);
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

//Get Leave Type
function GetAllLeaveType() {
    $.ajax({
        type: "GET",
        url: BaseURL + "Leave/GetAllLeaveType",
        contentType: "application/json;",
        dataType: "json",
        success: function (data) {
            // alert(data)
            var arr = [];
            arr = data;
            $.each(arr, function (i, item) {
                var options = "<option class='dropdown-item' value=" + item.LeaveTypeID + ">" + item.LeaveTypeName + "</option>";
                $('#leavetypedrop').append(options);
            }); //End of foreach Loop   
        }, //End of AJAX Success function  
        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
}

//Add Leave
function CreateLeave() {
    var leave = {
        "LeaveTypeID": $("#levetype").val(),
        "DateFrom": $("#startdate").val(),
        "DateTo": $("#enddate").val(),
        "Reason": $("#reason").val()
    };
    $.ajax({
        type: "POST",
        url: BaseURL+"Leave/Create",
        data: JSON.stringify(leave),
        contentType: "application/json",
        dataType: "json",
        cache: false,
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

// Approve
function changeApproveStatus(leaveid, ele) {
    if (ele.checked == true) {
        var s = confirm('Are you sure? You want to set order as Approve?');

        if (s == true) {


            var menuId = $("").first().attr("id");
            var request = $.ajax({
                url:BaseURL + "Leave/GetAll",
                type: "POST",
                data: {
                    orderId: leaveid,
                    leavestatus: "DELIVERED"
                },
                dataType: "html",
                success: function (response) {
                    $(ele).attr("disabled", true);
                    $("#status_" + orderId).html("DELIVERED");
                    $("#status_" + orderId).attr("style", "color:green")
                },
                error: function () {
                    alert("error");
                }
            });

        }
    }
}



=======
        url: "/api/Leave/Get",
        contentType: "json",
        dataType: "json",
        success: function (data) {

            $.each(data, function (key, value) {
                //stringify
                var jsonData = JSON.stringify(value);
                //Parse JSON
                var objData = $.parseJSON(jsonData);
                var id = objData.LeaveTypeID;
                var fromdate = objData.DateFrom;
                var todate = objData.DateTo;
                var reason = objData.Reason;
                var approve = objData.IsApproved;

                AppendTo('#leavetable');

            });
        },
        error: function () {
            alert("Error");
        }
    });
}
//Add Leave
function CreateLeave() {
    var cors = {
        "LeaveTypeID": $("#levetype").val(),
        "DateFrom": $("stratdate").val(),
        "DateTo": $("#enddate").val(),
        "Reason": $("#reason").val(),
        "IsApproved": $("#isapprove").val()
    };
    $.ajax({
        type: 'POST',
        url: '/api/Leave/Create',
        data: JSON.stringify(cors),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            alert("Create Leave Successfully");
        },
        error: function () {
            alert('error');

        }
    })
}

>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
