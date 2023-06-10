from ..custom_mixin import custom_get_serializer
from ..models import Services
from ..serializers import ServicesRetrieveSerializers, ServicesUpdateSerializers
from ..BaseAPI import BaseAPI


class ServicesAPI(custom_get_serializer,BaseAPI):
    queryset = Services.objects.all()
    serializer_class = ServicesRetrieveSerializers
    serializer_class_update_or_create = ServicesUpdateSerializers