//GET Leavetype By Id
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
        "LeaveTypeName": $("#leavetype").val()
    };
    $.ajax({
        type: 'POST',
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
}

//Edit Leavetype 
function EditLeaveType() {
    var cors = {
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
