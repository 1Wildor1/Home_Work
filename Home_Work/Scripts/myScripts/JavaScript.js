angular.module("KendoDemos", [])
    .controller("MyCtrl", function ($scope) {
        $scope.mainGridOptions = {
            dataSource: {
                type: "aspnetmvc-ajax",
                transport: {
                    read: {
                        type: "Get",
                        url: "/Student/GetStudent"
                    }
                },
                pageSize: 5,
                serverPaging: true,
                serverSorting: true
            },
            schema: {
                model: {
                    id: "Student",
                    fields: {
                        StudentId: { type: "number", validation: { required: true }},
                        FirstName: { type: "string", validation: { required: true } },
                        LastName: { type: "string", validation: { required: true } },
                        YearOfStudy: { type: "string", validation: { required: true } }
                    },
                }
            },
            sortable: true,
            pageable: 50,
            dataBound: function () {
                this.expandRow(this.tbody.find("tr.k-master-row").first());
            },
            columns: [{
                field: "StudentID",
                title: "Student ID",
                width: "120px"
            }, {
                field: "FirstName",
                title: "First Name",
                width: "120px"
            }, {
                field: "LastName",
                title: "Last Name",
                width: "120px"
            }, {
                field: "YearOfStudy",
                title: "Year Of Study",
                width: "120px"
            }]
        };

        $scope.detailGridOptions = function (dataItem) {
            return {
                dataSource: {
                    type: "odata",
                    transport: {
                        read: "https://demos.telerik.com/kendo-ui/service/Northwind.svc/Orders"
                    },
                    serverPaging: true,
                    serverSorting: true,
                    serverFiltering: true,
                    pageSize: 5,
                    filter: { field: "EmployeeID", operator: "eq", value: dataItem.EmployeeID }
                },
                scrollable: false,
                sortable: true,
                pageable: true,
                columns: [
                    { field: "OrderID", title: "ID", width: "56px" },
                    { field: "ShipCountry", title: "Ship Country", width: "110px" },
                    { field: "ShipAddress", title: "Ship Address" },
                    { field: "ShipName", title: "Ship Name", width: "190px" }
                ]
            };
        };
    })