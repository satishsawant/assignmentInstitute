$(document).ready(function () {
    GetAllCourse();
    GetCourseType();
<<<<<<< HEAD
    //GetCourseTypeById();
=======
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
});
var BaseURL = "http://45.35.4.250/institutemgmt/api/";
//GET couse By Id
function GetCourseById() {
    $.ajax({
        type: "GET",
        url: BaseURL+"Course/Get",
        contentType: "json",
        dataType: "json",
        success: function (data) {
            //stringify
            var jsonData = JSON.stringify(data);
            //Parse JSON
            var objData = $.parseJSON(jsonData);
            var objData = $.parseJSON(jsonData);
            var id = objData.CourseTypeId;
            var name = objData.CourseName;
            var due = objData.Duration;
            var fees = objData.Fees;
<<<<<<< HEAD
            AppendTo('#coursetable');
        },
          
=======

           AppendTo('#coursetable');
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
        error: function () {
            alert("Error");
        }
    });
}

<<<<<<< HEAD
=======
function GetCourseTypeById(id) {
    debugger;
    var courseTypeName = '';
    $.ajax({
        type: "GET",
        url: BaseURL + "Course/GetCourseType/"+id,
        contentType: "application/json;",
        dataType: "json",
        success: function (data) {
            // alert(data)
            var arr = [];
            arr = data;
            $.each(arr, function (i, item) {
                courseTypeName = item.CourseTypeName;
                
            }); //End of foreach Loop  
            return courseTypeName;
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
    
}

>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
//GetAll
function GetAllCourse() {
    debugger;
    $.ajax({
        type: "GET",
        url: BaseURL+ "Course/GetAll",
<<<<<<< HEAD
        contentType: "application/json",
=======
        contentType: "json",
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
        dataType: "json",
        success: function (data) {
            //var course = data.success;
            var arr = [];
            arr = data;
<<<<<<< HEAD
         
            $.each(arr, function (i, item) {
              
                var options = "<tr><td>" + item.CourseTypeId + "</td><td>" + item.CourseName + "</td><td>" + item.Duration + "</td> <td>" + item.Fees + "</td> <td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' onclick='setValueForEdit(" + '"' + item.CourseID + '","' + item.CourseTypeName + '","' + item.CourseName + '","' + item.Duration + '","' + item.Fees + '"' + ")' data-title='Edit' data-toggle='modal' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td>";
=======
            var courseTypeName;
            $.each(arr, function (i, item) {
                courseTypeName = GetCourseTypeById(item.CourseTypeId);
                var options = "<tr><td>" + courseTypeName + "</td><td>" + item.CourseName + "</td><td>" + item.Duration + "</td> <td>" + item.Fees + "</td> <td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' onclick='setValueForEdit(" + '"' + item.CourseID + '","' + item.CourseTypeName + '","' + item.CourseName + '","' + item.Duration + '","' + item.Fees + '"' + ")' data-title='Edit' data-toggle='modal' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>";
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
                $('#coursebody').append(options);
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

//Get Course type
function GetCourseType() {
<<<<<<< HEAD
    debugger;
=======
  
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
    $.ajax({
        type: "GET",
        url: BaseURL + "Course/getallcoursetype",
        contentType: "application/json;",
        dataType: "json",
        success: function (data) {
            // alert(data);
            var arr = [];
            arr = data;
            $.each(arr, function (i, item) {
                var options = "<option class='dropdown-item' value=" + item.CourseTypeId + ">" + item.CourseTypeName + "</option>";
                $('#coursetype').append(options);
                $('#Editcoursetype').append(options);
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

//Add Course
function CourseCreate() {
    //debugger;
    var cours = {
        "CourseTypeId": $("#coursetype").val(),
        "CourseName": $("#coursename").val(),
        "Duration": $("#coursedue").val(),
        "Fees": $("#coursefees").val()
    };
    $.ajax({
        type: "POST",
        url: BaseURL+ "Course/CreateCourse",
        data: JSON.stringify(cours),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
<<<<<<< HEAD
            alert("Create Succesfully");
=======
            alert(data);
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
        },
        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    })
}

//setValueForEdit
function setValueForEdit(id, courtypename, name, duration, fees) {
<<<<<<< HEAD
    debugger;
=======
    //debugger;
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
    $('#courseid').val(id);
    $('#coursetype').val(courtypename);
    $('#editcoursename').val(name);
    $('#editcoursedue').val(duration);
    $('#editcoursefees').val(fees);
}

//Edit Course 
function CourseEdit() {
    debugger;
    var cours = {
        "CourseID": $("#courseid").val(),
<<<<<<< HEAD
        "CourseTypeName": $("#Editcoursetype").val(),
=======
        "CourseTypeName": $("#coursetype").val(),
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
        "CourseName": $("#editcoursename").val(),
        "Duration": $("#editcoursedue").val(),
        "Fees": $("#editcoursefees").val()
    };
    $.ajax({
        type: "POST",
        url: BaseURL+"Course/UpdateCourse",
        data: JSON.stringify(cours),
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
<<<<<<< HEAD
            if (data = 'success') { alert('Updated Successfully') }
        }, //End of AJAX Success function  

=======
            alert(data);
        },
>>>>>>> 8cc6848140123ceae76ac7f81b965d492e5e97df
        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
<<<<<<< HEAD

    });
    $('#edit').modal('toggle');
}

////Delete ourse Type
function CourseDelete() {
    $.ajax({
        type: "DELETE",
        url: '/api/Course/DeleteCourseType',
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
    })
}
////Delete ourse Type
//function CourseDelete() {
//    $.ajax({
//        type: "DELETE",
//        url: '/api/Course/DeleteCourseType',
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
