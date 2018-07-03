
$(document).ready(function () {
    GetCourseType();
});
var BaseURL = "http://45.35.4.250/institutemgmt/api/";

//GEt All Course Type
function GetCourseType() {
    debugger;
    $.ajax({
        type: "GET",
        url: BaseURL + "Course/GetAllCourseType",
   
    $.ajax({
        type: "GET",
        url: BaseURL + "Course/getallcoursetype",
        contentType: "application/json;",
        dataType: "json",
        success: function (data) {
            // alert(data)
            var arr = [];
            arr = data;
            $.each(arr, function (i, item) {
                //var options = "<option class='dropdown-item' value=" + item.CourseID + ">" + item.CourseTypeName + "</option>";
                var options = "<tr><td>" + item.CourseTypeId + "</td><td>" + item.CourseTypeName + "</td><td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' onclick='setValueForEdit(" + '"' + item.CourseTypeId + '","' + item.CourseTypeName + '"' + ")' data-title='Edit' data-toggle='modal' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td>";
                var options = "<tr><td>" + item.CourseTypeId + "</td><td>" + item.CourseTypeName + "</td><td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' onclick='setValueForEdit(" + '"' + item.CourseTypeId + '","' + item.CourseTypeName + '"' + ")' data-title='Edit' data-toggle='modal' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>";
                $('#coursetypebody').append(options);
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

//Add Course Type
function CourseTypeCreate() {
    var course = {
        "CourseTypeName": $("#coursetype").val()
    };
    $.ajax({
        type: "POST",
        url: BaseURL + "Course/CreateCourseType",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(course),
        success: function (data) {
            alert("Create Succesfully");
            alert(data);
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
    $('#coursetypeid').val(id);
    $('#editcoursetypename').val(name);
}

//Edit Course Type
function CourseTypeEdit() {
    debugger;
    var course = {
        "CourseTypeName": $("#editcoursetypename").val(),
        "CourseTypeID": $('#coursetypeid').val()
    };
    $.ajax({
        type: "POST",
        url: BaseURL + "Course/UpdateCourseType",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(course),
        success: function (data) {
            if (data = 'success')
           { alert('Updated Successfully') }
        }, //End of AJAX Success function  
            alert(data);
        },

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
    $('#edit').modal('toggle');
}

    });
}

//$("body").on("click", "#coursesave", function () {
//    var Courtype = $("#coursetype");
//    var Courcheck = $("#coursecheck");
//    var course = {};
//    course.CourseType = Courtype.val();
//    course.CourseCheck = Courcheck.val();
//    $.ajax({
//        type: "POST",
//        url: "/api/AjaxAPI/InsertCustomer",
//        data: JSON.stringify(_customer),
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (c) {
//            var row = $("#tblCustomers tr:last-child").clone(true);
//            AppendRow(row, c.CourseTypeID, c.CourseTypeName, c.IsActive);
//            Courtype.val("");
//            Courcheck.val("");
//        }
//    });
//});



//Delete ourse Type
function CourseTypeDelete() {
    $.ajax({
        type: "DELETE",
        url: BaseURL + "Course/DeleteCourseType",
        contentType: "json",
        dataType: "json",
        success: function (data) {
            alert("success.... " + data);
        },
        error: function () {
            alert('error');
        }
    });
}
