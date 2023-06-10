from ..custom_mixin import custom_get_serializer
from ..models import Dentist
from ..serializers import DentistRetrieveSerializers, DentistUpdateSerializers
from ..BaseAPI import BaseAPI


class DentistAPI(custom_get_serializer,BaseAPI):

    queryset = Dentist.objects.all()
    serializer_class = DentistRetrieveSerializers
    serializer_class_update_or_create = DentistUpdateSerializers
