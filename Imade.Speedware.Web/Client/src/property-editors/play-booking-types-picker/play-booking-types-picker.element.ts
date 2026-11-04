import { customElement } from '@umbraco-cms/backoffice/external/lit';
import { SpeedwarePickerBaseElement } from '../speedware-picker.element.js';
import { ImadeSpeedwareWebService } from '../../api/index.js';
import type { PickerItem } from '../types.js';

@customElement('imade-speedware-play-booking-types-picker')
export class PlayBookingTypesPickerElement extends SpeedwarePickerBaseElement {
	protected readonly localizationKey = 'speedwarePlayBookingTypesPicker';

	protected async fetchItems(): Promise<PickerItem[]> {
		const { data } = await ImadeSpeedwareWebService.getPlayBookingTypes({ throwOnError: true });
		return data.map((t) => ({ id: t.id, label: t.name }));
	}
}

export default PlayBookingTypesPickerElement;

declare global {
	interface HTMLElementTagNameMap {
		'imade-speedware-play-booking-types-picker': PlayBookingTypesPickerElement;
	}
}
