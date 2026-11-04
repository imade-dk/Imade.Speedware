import { customElement } from '@umbraco-cms/backoffice/external/lit';
import { SpeedwarePickerBaseElement } from '../speedware-picker.element.js';
import { ImadeSpeedwareWebService } from '../../api/index.js';
import type { PickerItem } from '../types.js';

@customElement('imade-speedware-booking-types-picker')
export class BookingTypesPickerElement extends SpeedwarePickerBaseElement {
	protected readonly localizationKey = 'speedwareBookingTypesPicker';

	protected async fetchItems(): Promise<PickerItem[]> {
		const { data } = await ImadeSpeedwareWebService.getBookingTypes({ throwOnError: true });
		return data.map((t) => ({ id: t.id, label: t.name }));
	}
}

export default BookingTypesPickerElement;

declare global {
	interface HTMLElementTagNameMap {
		'imade-speedware-booking-types-picker': BookingTypesPickerElement;
	}
}
