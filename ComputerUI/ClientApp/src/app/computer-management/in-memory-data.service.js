"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var InMemoryDataService = /** @class */ (function () {
    function InMemoryDataService() {
    }
    InMemoryDataService.prototype.createDb = function () {
        var computers = [
            { "id": 1, "configuracionName": "The Basic", "memory": "4GB DDR3", "processor": "AMD", "hardDrive": "512GB HDD", "lastModified": "2018-04-01T01:29:17.9300101" },
            { "id": 2, "configuracionName": "The Internet", "memory": "4GB DDR3", "processor": "Intel i3", "hardDrive": "128GB SDD", "lastModified": "2018-04-01T01:29:17.9484223" },
            { "id": 3, "configuracionName": "The Gamer", "memory": "8GB DDR4", "processor": "Intel i5", "hardDrive": "1TB HDD", "lastModified": "2018-04-01T01:29:17.9484242" },
            { "id": 4, "configuracionName": "The Beast", "memory": "16GB DDR4", "processor": "Intel i7", "hardDrive": "512GB SDD", "lastModified": "2018-04-01T01:29:17.9484256" }
        ];
        return { computers: computers };
    };
    return InMemoryDataService;
}());
exports.InMemoryDataService = InMemoryDataService;
//# sourceMappingURL=in-memory-data.service.js.map