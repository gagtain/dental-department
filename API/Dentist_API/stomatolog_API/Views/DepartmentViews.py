from django.db.models import Q
from rest_framework.response import Response

from ..custom_mixin import custom_get_serializer
from ..models import Department, Services
from ..serializers import DepartmentRetrieveSerializers, DepartmentUpdateSerializers, \
    ServicesRetrieveSerializers
from ..BaseAPI import BaseAPI


class DepartmentAPI(custom_get_serializer,BaseAPI):

    queryset = Department.objects.all()
    serializer_class = DepartmentRetrieveSerializers
    serializer_class_update_or_create = DepartmentUpdateSerializers


    def retrieve_not_services(self,request, pk):
        return Response(ServicesRetrieveSerializers(Services.objects.filter(~Q(services_list=pk)), many=True).data)