<<<<<<< HEAD
﻿$(document).ready(function () {
    GetAllLeaveType();
});
var BaseURL = "http://45.35.4.250/institutemgmt/api/";

//GET Leavetype By Id
=======
﻿//GET Leavetype By Id
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
function GetLeaveTypeById() {
    $.ajax({
        type: "GET",
        url: "/api/Leave/GetLeaveType",
        contentType: "json",
        dataType: "json",
        success: function (data) {
            //stringify
            var jsonData = JSON.stringify(data);
            //Parse JSON
            var objData = $.parseJSON(jsonData);
            var objData = $.parseJSON(jsonData);
            var id = objData.LeaveTypeID;
            var name = objData.LeaveTypeName;

            AppendTo('#coursetable');
        },
        error: function () {
            alert("Error");
        }
    });
}
<<<<<<< HEAD

//GetAll Leavetype
function GetAllLeaveType() {
    debugger;
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
                //var options = "<option class='dropdown-item' value=" + item.CourseID + ">" + item.CourseTypeName + "</option>";
                var options = "<tr><td>" + item.LeaveTypeID + "</td><td>" + item.LeaveTypeName + "</td><td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit' onclick='setValueForEdit(" + '"' + item.LeaveTypeID + '","' + item.LeaveTypeName + '"' + ")' data-toggle='modal' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>";
                $('#leavetypebody').append(options);
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

//Add Leavetype
function CreateLeaveType() {
    debugger;
    var leave = {
=======
//GetAll Leavetype
function GetAllLeaveType() {
    $.ajax({
        type: "GET",
        url: "/api/Leave/GetAllLeaveType",
        contentType: "json",
        dataType: "json",
        success: function (data) {

            $.each(data, function (key, value) {
                //stringify
                var jsonData = JSON.stringify(value);
                //Parse JSON
                var objData = $.parseJSON(jsonData);
                var id = objData.LeaveTypeID;
                var name = objData.LeaveTypeName;
              
                AppendTo('#coursetable');

            });
        },
        error: function () {
            alert("Error");
        }
    });
}
//Add Leavetype
function CreateLeaveType() {
    var cors = {
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
        "LeaveTypeName": $("#leavetype").val()
    };
    $.ajax({
        type: 'POST',
<<<<<<< HEAD
        url: BaseURL+"Leave/CreateLeaveType",
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
    });
}

//setValueForEdit
function setValueForEdit(id, name) {
    //debugger;
    $('#leavetypeid').val(id);
    $('#editleavetype').val(name);
=======
        url: '/api/Leave/CreateLeaveType',
        data: JSON.stringify(cors),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            alert("Create Leave Type Successfully");
        },
        error: function () {
            alert('error');

        }
    })
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
}

//Edit Leavetype 
function EditLeaveType() {
    var cors = {
<<<<<<< HEAD
        "LeaveTypeName": $("#editleavetype").val()
    };
    $.ajax({
        type: "POST",
        url: BaseURL+"Leave/UpdateLeaveType",
        data: JSON.stringify(courseEdit),
        contentType: "application/json",
        dataType: "json",
        cache: false,
        success: function (data) {
            if (data = 'success') { alert('Updated Successfully') }
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
    $('#edit').modal('toggle');
}

////Delete Leavetype Type
function LeaveDelete() {
    $.ajax({
        type: "DELETE",
        url: '/api/Leave/DeleteCourseType',
        contentType: "json",
        dataType: "json",
        success: function (data) {
            alert("success.... " + data);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}
=======
        "LeaveTypeName": $("#leavetype").val()
    };
    $.ajax({
        type: 'PUT',
        url: '/api/Leave/UpdateLeaveType',
        data: JSON.stringify(courseEdit),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            alert("Edit Leave Type Successfully");
        },
        error: function () {
            alert('error');

        }
    })
}
////Delete Leavetype Type
//function LeaveDelete() {
//    $.ajax({
//        type: "DELETE",
//        url: '/api/Leave/DeleteCourseType',
//        contentType: "json",
//        dataType: "json",
//        success: function (data) {
//            alert("success.... " + data);
//        },
//        error: function (xhr) {
//            alert(xhr.responseText);
//        }
//    });
//}
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
