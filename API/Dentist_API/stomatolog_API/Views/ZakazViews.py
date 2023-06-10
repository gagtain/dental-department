from rest_framework import mixins, viewsets, status
from django.shortcuts import get_object_or_404
from rest_framework.response import Response

from ..models import Department, MyUser
from ..serializers import ZakazSerializers


class ZakazAPI(mixins.RetrieveModelMixin,
               viewsets.GenericViewSet):

    queryset = Department.objects.all()
    serializer_class = ZakazSerializers

    def zakaz_list(self, request, pk):
        user = get_object_or_404(MyUser, pk=pk)
        serializers = self.serializer_class(user.zakaz_list.order_by('-id'), many=True)
        return Response({'zakaz_list':serializers.data}, status=status.HTTP_200_OK)

    def retrieve(self, request, pk, zakaz_pk):
        user = get_object_or_404(MyUser, pk=pk)
        serializers = self.serializer_class(user.zakaz_list.get(id=zakaz_pk))
        return Response(serializers.data, status=status.HTTP_200_OK)


