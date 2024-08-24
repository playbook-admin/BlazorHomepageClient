window.fileUpload = {
  initializeDropZone: function (dotNetHelper) {
    const dropZone = document.getElementById("dropZone");

    dropZone.addEventListener('dragenter', function (e) {
      e.preventDefault();
      console.log("dragenter")
      dotNetHelper.invokeMethodAsync('HandleDragEnter');
    });

    dropZone.addEventListener('dragover', function (e) {
      e.preventDefault();
      console.log("dragover")
      dotNetHelper.invokeMethodAsync('HandleDragOver');
    });

    dropZone.addEventListener('dragleave', function (e) {
      e.preventDefault();
      console.log("dragleave")
      dotNetHelper.invokeMethodAsync('HandleDragLeave');
    });

    dropZone.addEventListener('drop', function (e) {
      e.preventDefault();
      console.log("drop")
      const files = e.dataTransfer.files;
      if (files.length > 0) {
        dotNetHelper.invokeMethodAsync('HandleDrop', files[0].name);
      }
    });
  }
};
