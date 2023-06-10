from rest_framework.mixins import *



class custom_retrieve:

    def retrieve(self, request, *args, **kwargs):
        if kwargs['pk'] <= 0:
            return Response(status=status.HTTP_400_BAD_REQUEST, data={'errors':'No valid, pk'})
        instance = self.get_object()
        serializer = self.get_serializer(instance)
        return Response(serializer.data)

class custom_get_serializer:

    def get_serializer_class(self):
        if self.action == "create" or self.action == "update" or self.action == "partial_update":
            return self.serializer_class_update_or_create
        return self.serializer_class

