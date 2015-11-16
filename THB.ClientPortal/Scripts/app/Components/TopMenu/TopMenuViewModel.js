﻿function TopMenuViewModel() {
    var self = this;

    self.viewModels = ko.observableArray(["Zlecenia", "Dodaj"]);
}

ko.components.register("top-menu-nc", {
    viewModel: TopMenuViewModel,
    template: { element: "top-menu-view" }
});

