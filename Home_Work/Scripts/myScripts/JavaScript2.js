﻿//debugger;
//    let myDataArray = [
//    {ID: 1, Name: "Tom", Date: "10/15/2022" },
//    {ID: 2, Name: "John", Date: "11/25/2022" },
//    {ID: 3, Name: "Annie", Date: "05/09/2022" },
//    {ID: 4, Name: "Rachel", Date: "08/06/2022" },
//    {ID: 5, Name: "Klemens", Date: "10/07/2022" },
//    {ID: 6, Name: "Micah", Date: "05/19/2022" },
//    {ID: 7, Name: "Junie", Date: "04/04/2022" },
//    {ID: 8, Name: "Krishnah", Date: "07/19/2022" },
//    {ID: 9, Name: "Enrichetta", Date: "01/11/2022" },
//    {ID: 10, Name: "Marten", Date: "02/13/2022" },
//    {ID: 11, Name: "Rosmunda", Date: "08/15/2022" },
//    ];

//    $("#my-grid").kendoGrid({
//        width: "700px",
//    height: "400px",

//    toolbar: ["create", "save"],
//    filterable: true,
//    editable: true,

//    columns: [
//    {field: "ID", title: "Personal Id", width: "70px" },
//    {field: "Name", title: "First Name", width: "150px" },
//    {field: "Date", title: "Hire Date", width: "200px", format: "{0:dd-MM-yyyy}" }
//    ],
//    dataSource: {
//        data: myDataArray,
//    schema: {
//        model: {
//        id: "ID",
//    fields: {
//        ID: {type: "number", editable: false },
//    Name: {type: "string", editable: false },
//    Date: {type: "date", editable: false }
//                    }
//                }
//            }
//        }
//    })

function myFunck() {
   ///* $.ajax({*/
   //     method: 'Get',
   //     url: '/StudentApp/Controllers/StudentAction/CreateStudent',
   //     success: function () {
   //         alert('saved');

   //     },
   //     error: function () {
   //         alert('Oups smth went wrong')
   //     }
   // });

    open('/StudentAction/CreateStudent');
}

myFunck();