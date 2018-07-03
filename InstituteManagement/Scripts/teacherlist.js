$(document).ready(function () {
    getTeacherList();
});
var BaseUrl = "http://45.35.4.250/institutemgmt/api/";

function getDepartmentById(id) {
    debugger;
    var str = '';
    $.ajax({
        type: "GET",
        url: BaseUrl + "Department/getdepartment/" + id,
        contentType: "application/json;",
        dataType: 'json',
        success: function (data) {
            // alert(data);
            //var res = JSON.parse(data);
            var teachers = data.success;
            var arr = [];
            arr = data.departments;
            $.each(arr, function (i, item) {
                str = item.Department_Name;
            }); //End of foreach Loop   
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
    return str;
}

function getTeacherList() {
    debugger;
    $.ajax({
        type: "GET",
        url: BaseUrl + "Teacher/GetTeacher/0",
        contentType: "application/json;",
        dataType: 'json',
        success: function (data) {
            // alert(data);
            //var res = JSON.parse(data);
            var teachers = data.Success;
            var arr = [];
            arr = data.Teacher;
            if (arr.length > 0) {
                $.each(arr, function (i, item) {
                    var dept = getDepartmentById(item.DeptId);
                    var options = "<tr><td>" + item.First_Name + " " + item.Last_Name + "</td>" + "<td>" + item.Gender + "</td><td>" + item.ContactNo + "</td><td>" + item.City + "</td><td>" + item.Country + "</td><td>" + item.Pin + "</td><td>" + item.Payment + "</td><td>" + item.Designation + "</td><td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit' onclick='editTeacher(" + item + ")' data-toggle='modal' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>";
                    $('#teachertablebody').append(options);
                }); //End of foreach Loop   
            }
            else {
                $('#teachertablebody').append("<tr><td colspan='10'> No Teachers are available </td></tr>");
            }

        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
}