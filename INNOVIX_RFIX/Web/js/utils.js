var util = {
    convertStringDate: function (value) {
        return new Date(parseInt(value.slice(6, -2)));
    }
};