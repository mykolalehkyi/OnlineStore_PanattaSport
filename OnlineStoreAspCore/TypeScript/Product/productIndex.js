var ProductIndexPageController = /** @class */ (function () {
    function ProductIndexPageController() {
        var _this = this;
        $(document).ready(function () { return _this.init(); });
    }
    ProductIndexPageController.prototype.init = function () {
        this.initDataTable();
    };
    ProductIndexPageController.prototype.initDataTable = function () {
        this.datatable = $("#productTable");
        $("#productTable").DataTable({
            "ajax": {
                "url": "/Product/GetList",
                "type": "GET",
                "dataType": "json",
                "data": this.tableData
            },
            "columns": [
                { "data": "productId" },
                { "data": "productName" },
                { "data": "width" },
                { "data": "length" },
                { "data": "height" },
                { "data": "weight" },
                { "data": "standardLoad" },
                { "data": "optionalLoad" },
            ]
        });
    };
    ProductIndexPageController.prototype.getMuscleLoadCheckedValues = function () {
        var checkedArray = $('.checkbox-muscle-load:checked').map(function () {
            return parseInt($(this).val().toString());
        }).get();
        return checkedArray;
    };
    ProductIndexPageController.prototype.createCategoriesProductRequestDTO = function () {
        var muscleLoadRequestDTO = new CategoriesProductRequestDTO();
        muscleLoadRequestDTO.muscleLoadIds = this.getMuscleLoadCheckedValues();
        return muscleLoadRequestDTO;
    };
    ProductIndexPageController.prototype.applyCategories = function () {
        var categoriesProductRequestDTO = this.createCategoriesProductRequestDTO();
        $.ajax({
            type: 'POST',
            url: "/Product/GetListCategorized",
            data: { MuscleLoadIds: this.getMuscleLoadCheckedValues() },
            dataType: 'json',
            success: this.populateDataTable,
            error: function (e) {
                console.log("There was an error with your request...");
                console.log("error: " + JSON.stringify(e));
            }
        });
    };
    ProductIndexPageController.prototype.populateDataTable = function (dataToTable) {
        this.datatable = $("#productTable").DataTable();
        this.datatable.clear().draw();
        this.datatable.rows.add(dataToTable.data); // Add new data
        this.datatable.columns.adjust().draw(); // Redraw the DataTable
    };
    return ProductIndexPageController;
}());
var CategoriesProductRequestDTO = /** @class */ (function () {
    function CategoriesProductRequestDTO() {
    }
    return CategoriesProductRequestDTO;
}());
var productIndexPageController = new ProductIndexPageController();
//# sourceMappingURL=productIndex.js.map