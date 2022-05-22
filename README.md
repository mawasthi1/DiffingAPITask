# DiffingAPITask

In this API I have created a model for the Diff, this model stores data, length, offset, position. Each time a put request is made with the proper data
the API will store the given data into the data model. At this time the API will also update variables that hold the results.

When a get request is made the API will check the result variable in order to determine the output that needs to be given for the request in JSON format. 
